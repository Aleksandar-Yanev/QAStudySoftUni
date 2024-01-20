function censoredWords(text, word) {
    'use strict';

    function repeat(word) {
        
            const times = word.length;
            return '*'.repeat(times);
        
    }

    let censored = text.replace(word, repeat(word));
    while (censored.includes(word)) {
        censored = censored.replace(word, repeat(word));
    }

    console.log (censored);
}

censoredWords('A small sentence with some small words', 'small');
censoredWords('Find the hidden word', 'hidden');