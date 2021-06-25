const client = require('./redis')
const { v4: uuidv4 } = require('uuid');


const getBasket = (req, res) => {
    client.GET(req.params.id, (err, value) => {
        if (err || value === null) {
            res.status(404).send("Not Found")
            if (err) console.log(err.message)
        }
        else{
            res.status(200).json(JSON.parse(value))
        }
    })
}

const createBasket = (req, res) => {
    const id = uuidv4();
    console.log(id + " " + req.body)
    let newBasket = [];
    newBasket = newBasket.concat(req.body)
    console.log(newBasket)
    client.SET(id, JSON.stringify(newBasket))
    res.status(200).json(id)
}

const addToBasket = (req, res) => {
    const id = req.params.id
    if (id !== undefined) {
        let basket = []
        client.GET(id, (err, value) => {
            if (err || value === null) {
                res.status(404).send("Not Found")
                if (err) console.log(err.message)
            } else {            
                console.log(value)
                basket = JSON.parse(value)
                let updatedBasket = basket.concat(req.body)
                console.log(updatedBasket)
                client.SET(id, JSON.stringify(updatedBasket))
                res.status(200).json(updatedBasket)
            }
        })
    } else {
    res.status(400).json("error")
    }
}

const resetRedis = (req, res) => {
    const password = req.params.password
    if (password === process.env.RESET_REDIS_PW) {        
        client.flushall((err, success) => {
            if (err) console.log(err.message)
            console.log(success)
            res.status(200).json(success)
        })
    } else {
        res.status(400).json("error")
    }
}

const deleteBasket = (req, res) => {
    const basketId = req.params.id
    client.DEL(basketId, (err, value) => {
        if (err || value===0) {
            res.status(404).send("Not Found")
            if(err){
                console.log(err.message)
            }
        }
        else{
            res.status(200).json(`Basket:${basketId} deleted`)
        }
    })
}

module.exports = {
    getBasket,
    createBasket,
    addToBasket,
    resetRedis,
    deleteBasket
}