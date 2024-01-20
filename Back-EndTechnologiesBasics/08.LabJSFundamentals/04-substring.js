function substring (inputString, startingIndex, count){
    'use strict';

let endIndex = startingIndex + count;
    let modifiedString = inputString.slice(startingIndex, endIndex);
    console.log (modifiedString);
}

substring('ASentence', 1, 8);
substring('SkipWorde', 4, 7);