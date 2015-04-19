db.zips.findOne()
db.zips.aggregate([
{$project:
    {
        _id: 1,
        pop: 1,
        first_char: {$substr : ["$city",0,1]}
    }
},
{$match: {first_char: {$in: ["0","1","2","3","4","5","6","7","8","9"]}}},
{$group: {_id: "$first_char", pop_sum: {$sum: "$pop"}}},
{$group: {_id: null, pop_sum: {$sum: "$pop_sum"}}}
])


