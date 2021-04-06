m = process.argv.slice(2)
r = ""
if (m[0]) {
    v = m[0]
    m[0].split('').forEach(x => {
        u = v
        v.split('').forEach(y => {
            z = 0
            m.forEach(e => { if (e.includes(u)) z++ });
            if (z == m.length && u.length > r.length) { r = u }

            u = u.slice(0, -1)
        })
        v = v.slice(1)
    })
}

console.log(r)