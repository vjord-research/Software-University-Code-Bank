function fruitOrVeggie([word]) {
    switch (word) {
        case 'banana':
        case 'apple':
        case 'kiwi':
        case 'cherry':
        case 'lemon':
        case 'grapes':
        case 'peach':
            console.log('fruit'); break;
        case 'tomato':
        case 'cucumber':
        case 'pepper':
        case 'onion':
        case 'parsley':
        case 'garlic':
            console.log('vegetable'); break;
        default:
            console.log('unknown');
    }
}

fruitOrVeggie(['banana']);
fruitOrVeggie(['cucumber']);
fruitOrVeggie(['pizza']);