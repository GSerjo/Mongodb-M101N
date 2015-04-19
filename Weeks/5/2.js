db.zips.findOne()
db.zips.aggregate([
// {$match: {state: {$in: ["CT", "NJ"]}}},
{$match: {state: {$in: ["CA", "NY"]}}},
{$match: {pop: {$gt: 25000}}},
{$group: {_id: {state: "$state", city: "$city"}, pop_sum: {$sum: "$pop"}}},
{$group: {_id: "$_id.state", pop_avg: {$avg: "$pop_sum"}}}
])


