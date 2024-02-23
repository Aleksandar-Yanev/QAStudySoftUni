function phoneBook(input) {
    'use strict';

    let personName = {};
    input.forEach(element => {
        let keyValuePair = element.split(' ');
        let name = keyValuePair[0];
        personName [name] = keyValuePair[1];
    });

    for (let key in personName){
        console.log(`${key} -> ${personName[key]}`)
    }
}

phoneBook(['Tim 0834212554',
    'Peter 0877547887',
    'Bill 0896543112',
    'Tim 0876566344']);