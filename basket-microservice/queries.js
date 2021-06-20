const client = require('./redis')
const { v4: uuidv4 } = require('uuid');


const getBasket = (req, res) => {
    client.GET(req.params.id, (err, value) => {
        if (err) console.log(err.message)
        console.log(value)
        res.status(200).json(JSON.parse(value))
    })
}

const createBasket = (req, res) => {
    const id = uuidv4();
    console.log(id + " " + req.body.basket)
    client.SET(id, JSON.stringify(req.body))
    res.status(200).json(id)
}

module.exports = {
    getBasket,
    createBasket
}