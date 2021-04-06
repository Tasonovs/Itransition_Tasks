console.log(lcs(process.argv.slice(2)))

function lcs(input) {
    let result = ""
    if (input.length) {
        let word1 = input[0]
        input[0].split('').forEach(char1 => {
            let word2 = word1
            word1.split('').forEach(char2 => {
                z = 0
                input.forEach(element => { if (element.includes(word2)) z++ });
                if (z == input.length && word2.length > result.length) { result = word2 }

                word2 = word2.slice(0, -1)
            })
            word1 = word1.slice(1)
        })
    }

    return result
}