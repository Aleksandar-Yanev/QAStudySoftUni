function solve (fruit, weightInGr, pricePerKg){
    'use strict';

    let weightInKg = weightInGr / 1000;
    let money = weightInKg * pricePerKg;

    console.log(`I need $${money.toFixed(2)} to buy ${weightInKg.toFixed(2)} kilograms ${fruit}.`);
}

solve ('orange', 2500, 1.80);
solve ('apple', 1563, 2.35);