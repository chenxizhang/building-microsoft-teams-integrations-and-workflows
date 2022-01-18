import React, { useEffect } from "react";
import { Welcome } from "./sample/Welcome";
import * as microsoftTeams from "@microsoft/teams-js";

var showFunction = Boolean(process.env.REACT_APP_FUNC_NAME);
export default function Tab() {

  useEffect(() => {
    microsoftTeams.initialize();
  }, [])

  return (
    <div>
      {/* <Welcome showFunction={showFunction} /> */}

      {/* <button onClick={() => {
        microsoftTeams.tasks.startTask({
          title: "请输入数据",
          url: "https://localhost:53000/index.html#/input"
        }, (error, result) => {
          if (error)
            console.error(error);
          if (result) {
            console.log(result);

          }
        });
      }}>显示对话框</button> */}


      <button onClick={() => {
        var card = `{
          "type": "AdaptiveCard",
          "body": [
            {
              "type": "TextBlock",
              "size": "Medium",
              "weight": "Bolder",
              "text": "请提供你的联系方式"
            },
            {
              "type": "TextBlock",
              "text": "我们将尽快和你取得联系",
              "wrap": true
            },
            {
              "type": "ColumnSet",
              "columns": [
                {
                  "type": "Column",
                  "width": "stretch",
                  "items": [
                    {
                      "type": "Input.Text",
                      "id":"name",
                      "placeholder": "姓名"
                    }
                  ]
                }
              ]
            },
            {
              "type": "ActionSet",
              "actions": [
                {
                  "type": "Action.Submit",
                  "title": "提交"
                }
              ]
            }
          ],
          "$schema": "http://adaptivecards.io/schemas/adaptive-card.json",
          "version": "1.4"
        }`;


        const taskInfo: microsoftTeams.TaskInfo = {
          card: card
        }

        microsoftTeams.tasks.startTask(taskInfo, (err, result) => {
          console.log(err, result);
        })

      }}>显示卡片</button>


      <a href="https://teams.microsoft.com/l/task/<APP_ID>?url=<TASKINFO.URL>&height=<TASKINFO.HEIGHT>&width=<TASKINFO.WIDTH>&title=<TASKINFO.TITLE>">
        
      </a>


    </div>
  );
}
