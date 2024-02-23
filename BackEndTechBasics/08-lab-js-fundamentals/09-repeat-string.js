function repeat (string, count) {
    'use strict';
    let repitedString = '';
    for (let i = 0; i < count; i ++) {
        repitedString += string;
    }
    return repitedString;
}