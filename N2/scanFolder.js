const fs = require('fs')
const { SHA3 } = require('sha3')

fs.readdirSync("./").forEach(file => {
    if (fs.lstatSync(file).isDirectory()) return

    let fileContent = fs.readFileSync(file)
    let hashCode = new SHA3(256).update(fileContent).digest('hex')
    console.log(`${file} ${hashCode}`)
})