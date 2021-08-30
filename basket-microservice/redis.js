const redis = require("redis");

const client = redis.createClient({
    host: process.env.REDIS_URL,
})

client.on('connect', () => {
    console.log("client connected")
})

client.on('ready', () => {
    console.log("client ready")
})

client.on('error', (err) => {
    console.log(err.message)
})

module.exports = client