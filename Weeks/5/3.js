db.grades.findOne()
db.grades.aggregate([
{"$unwind" : "$scores"},
{$match: {"scores.type": {$ne: "quiz"}}},
{$group: {_id: {"student_id": "$student_id", class_id:"$class_id"}, student_avg: {$avg: "$scores.score"}}},
{$group: {_id: "$_id.class_id", class_avg: {$avg: "$student_avg"}}},
{$sort: {class_avg: 1}}
])


