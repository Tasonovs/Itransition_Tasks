describe("commonString", function() {
    describe("возвращает самую длинную общую подстроку всех переданных строк", function() {

        function makeTest(task, expected) {
            it("'" + task.toString() + "' => '" + expected + "'", function() {
                assert.equal(lcs(task), expected)
            })
        }

        makeTest([], "")
        makeTest([""], "")
        makeTest(["ABCDEFGH"], "ABCDEFGH")
        makeTest(["ABCDEFZ", "WBCDXYZ"], "BCD")
        makeTest(["132", "12332", "12312"], "1")
        makeTest(["ABCDEFGH", "ABCDEFG", "ABCEDF", "ABCED"], "ABC")
        makeTest(["ABCDEFGH", "ABCDEFG", "ABCEDF", "ABCED"], "ABC")
        makeTest(["ABCDEFGH", "ABCDEFG", "ABCDEF", "ABCDE"], "ABCDE")
        makeTest(["ABCDEFGH", "ABCDEFG", "ABCDEF", "ABCDE", "EDCBA"], "A")
        makeTest(["ABCDEFGH", "ABCDEFG", "ABCDEF", "ABCDE", "EDCBCA"], "BC")
        makeTest(["ABCDEFGH", "ABCDEFG", "AxBCDEF", "ABCDxE", "EDCBCAABCD"], "BCD")
        makeTest(["ABCDEFGH", "1234"], "")
        makeTest(["ABCQEFDEFGHIJ", "BCXEFGYZBCDEWEFGHU"], "EFGH")
    })
})