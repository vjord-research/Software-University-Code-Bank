let capitals = ['Sofia', 'Washington', 'London', 'Paris'];

for (let capital of capitals)
    console.log(capital);

for (let i in capitals)
    console.log(i + " " + capitals[i]);

for (let i = 0; i < capitals.length; i++)
    console.log(capitals[i]);

capitals.forEach(capital => console.log(capital));

capitals.forEach((capital, i) => console.log(i + ' -> ' + capital));

console.log(capitals.join(', '));

console.log(JSON.stringify(capitals));