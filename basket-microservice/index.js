const express = require('express');
const app = express();
app.use(express.json());
const dotenv = require('dotenv');
dotenv.config();
var cors = require('cors');
app.use(cors());
const db = require('./queries')


app.get('/api/basket/:id', db.getBasket)

app.post('/api/basket', db.createBasket)


const port = process.env.PORT || 3000;
app.listen(port, () => console.log(`Listening on port ${port}`));