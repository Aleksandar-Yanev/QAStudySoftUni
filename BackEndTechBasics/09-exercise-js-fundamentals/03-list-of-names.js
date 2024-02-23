function listOfNames (arrayOfNames) {
    'use strict';

    arrayOfNames.sort((a, b) => a.localeCompare(b));

    for (let index = 0; index < arrayOfNames.length; index ++){
        console.log(`${index +1}.${arrayOfNames[index]}`);
    }
}

listOfNames(["John", "Bob", "Christina", "Ema"]);