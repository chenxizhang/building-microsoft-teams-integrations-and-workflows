import * as microsoftTeams from "@microsoft/teams-js";
import { useEffect, useState } from "react";

export default () => {
    const [id, setId] = useState<string>();

    useEffect(() => {
        microsoftTeams.initialize();
    }, []);

    return <div>
        <input onChange={(event) => {
            setId(event.target.value);
            console.log(id);

        }}></input>
        <button onClick={() => {
            microsoftTeams.tasks.submitTask(id);//提交数据
        }}>提交</button>
    </div>
}