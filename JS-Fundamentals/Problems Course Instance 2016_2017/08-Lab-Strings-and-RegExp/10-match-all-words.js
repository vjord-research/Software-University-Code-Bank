function matchAllWords([text]) {
    let words = text.match(/\w+/g);
    console.log(words.join('|'));
}

matchAllWords(['A Regular Expression needs to have the global flag in order to match all occurrences in the text']);
matchAllWords(['_(Underscores) are also word characters']);