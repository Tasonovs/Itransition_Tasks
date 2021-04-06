var UglifyJS = require('uglify-js')

//get a reference to the minified version of file-1.js
var result = UglifyJS.minify("lcs.code.js")

//view the output
console.log(result.code)