const redis = require("redis");

const client = redis.createClient(process.env.REDIS_URL, {
    tls: {
        rejectUnauthorized: false
    }
});

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