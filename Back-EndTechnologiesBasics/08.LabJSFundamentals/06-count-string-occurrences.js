function count(text, searchedWord) {
    'use strict';
    let words = text.split(' ');
    let counter = 0;
    for (let word of words) {
        if (searchedWord === word) {
            counter++;
        }
    }
    console.log(counter);
}

count ('This is a word and it also is a sentence','is');