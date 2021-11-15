const express = require('express');
const path = require('path');
const application = express(),
      bodyParser = require("body-parser");
      port = 3080;

const users = [];

application.use(express.urlencoded());
application.use(express.json());
application.use(express.static(path.join(__dirname,'../NotEBookWebApp/build')));

//GET request for current users, return json file
application.get('/NodeJS_API/users', (req, res) => {
   console.log('api/users called!');
   res.json(users);
});

//POST call to add current user to users[]
application.post('/NodeJS_API/user',(req,res) => {
   const user = req.body.user;
   console.log('Adding user::::', user);
   users.push(user);
   res.json('user added');
});

//load index.html
application.get('/', function (req, res) {
   res.sendFile(path.join(__dirname,'../NotEBookWebApp/build/index.html'))
});

application.listen(port, () => {
   console.log(`Server listening on the port::${port}`);
});