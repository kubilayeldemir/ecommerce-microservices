const client = require('./redis')



const getBasket = (req, res) => {
    client.GET(req.params.id, (err, value) => {
        if (err) console.log(err.message)
        console.log(value)
        res.status(200).json(JSON.parse(value))
    })
}

const createBasket = (req, res) => {
    console.log(req.body.id + " " + req.body.basket)
    client.SET(req.body.id, JSON.stringify(req.body.basket))
    res.status(200).json(req.body.id)
}

module.exports = {
    getBasket,
    createBasket
}