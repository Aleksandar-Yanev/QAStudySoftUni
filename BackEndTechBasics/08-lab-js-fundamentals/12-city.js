function city(input) {
    'use strict';

    for ( let key in input) {
        console.log(`${key} -> ${input[key]}`);
    }
}

city ({
    name: "Sofia",
    area: 492,
    population: 1238438,
    country: "Bulgaria",
    postCode: "1000"
});