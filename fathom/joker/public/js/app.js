/*!
 * Joker
 * Copyright(c) 2021 End House Software
 * 
 * Version 1.0.0  Initial Version
 */

'use strict'

async function clickNextJoke() {
    var retData = "";

    const response = await $.post("/getjoke", {
        key1 : "val1"
    },
    function(data,status) {
        retData = data;
        console.log("Next Joke: " + retData);
    });

    return retData;
}
