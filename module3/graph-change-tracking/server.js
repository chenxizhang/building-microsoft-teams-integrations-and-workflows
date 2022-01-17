const express = require("express");
const bodyParser = require("body-parser");

const app = express();
app.use(bodyParser.json());

app.use("/", (req, res) => {
    if (req.query.validationToken) {
        res.send(req.query.validationToken)
    }
    else {
        console.log(req.body);
        res.send("hello,world")

    }
});

app.listen(3000, () => {
    console.log(`listen on 3000`);
})