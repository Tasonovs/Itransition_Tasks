console.log(f(process.argv.slice(2)))

function f(arr) {
    result = ""
    arrLength = arr.length
    if (!arrLength) return result
    firstWordLength = arr[0].length

    for (i = 0; i <= firstWordLength; i++) {
        for (j = i + 1; j <= firstWordLength; j++) {
            substr = arr[0].substring(i, j)
            for (p = 1; p < arrLength; p++) {
                if (!arr[p].includes(substr)) break
            }
            if (p === arrLength && substr.length > result.length) result = substr
        }
    }

    return result
}