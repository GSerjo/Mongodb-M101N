db.zips.findOne()
//db.zips.aggregate([{$group: {_id: "$state", population: {$sum: "$pop"}}}])
//db.zips.aggregate([{$group: {_id: "$state", avg_pop: {$avg: "$pop"}}}])
//db.zips.aggregate([{$group: {_id: "$city", postal_codes: {$addToSet: "$_id"}}}])
//db.zips.aggregate([{"$group":{"_id":"$city", "postal_codes":{"$push":"$_id"}}}])
//db.zips.aggregate([{"$group":{"_id":"$city", "postal_codes":{"$addToSet":"$_id"}}}])
//db.zips.aggregate([{$group: {_id: "$state", pop: {$max: "$pop"}}}])
//db.zips.aggregate([{$project: {_id:0, loc: 0, city:"$city", pop:"$pop", state:"$state", zip:"$_id"}}])
//db.zips.aggregate([{$match:{pop:{$gt:100000}}}])
//db.zips.aggregate([{$sort:{state: 1, city: 1}}])

