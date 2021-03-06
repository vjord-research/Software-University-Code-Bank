function lastKNumbersSeq(arr) {
    let [n, k] = arr.map(Number);
    let seq = [1];
    for (let i = 1; i < n; i++) {
        let start = Math.max(0, i - k);
        let end = i - 1;
        let sum = 0;
        for (let j = start; j <= end; j++)
            sum += seq[j];
        seq[i] = sum;
    }
    console.log(seq.join(' '));
}

lastKNumbersSeq(['6', '3']);
lastKNumbersSeq(['8', '2']);