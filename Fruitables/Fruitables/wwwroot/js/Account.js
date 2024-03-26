var MainClassElem = document.getElementsByClassName('main')[0];
var Flag = false;
var count = 0;
var countdown = 0;


let executed = false;

document.getElementById('signUpBtn').onclick = async function () {
    if (!executed) {
        executed = true;

        await new Promise(resolve => {
            setTimeout(() => {
                IncreaseHeight('userNameSpan', 'userName');
                IncreaseHeight('emailSpan', 'email');
                IncreaseHeight('passSpan', 'pass');
                IncreaseHeight('confirmPassSpan', 'confirmPass');
                IncreaseHeight('roleSpan', 'role');
                IncreaseHeight('PhoneSpan', 'Phone');
                Flag = true;
                resolve();
            }, 1);
        });
        MainClassElem.style.height = (parseInt(MainClassElem.clientHeight) + count * 21) + 'px';
    }
    DivSummarySignUp.style.display = 'block';
};
document.getElementById('userName').oninput = function () {
    if (!document.getElementById('userNameSpan').innerHTML == "") {
        countdown--;
        MainClassElem.style.height = (parseInt(MainClassElem.clientHeight) + countdown * 10) + 'px';
    }
}


function IncreaseHeight(span, input) {
    if (!document.getElementById(span).innerHTML == "") {
        count++;
    }
}


var LoginButton = document.getElementById('loginButton')
var XButton = document.getElementById('buttonX')
var YButton = document.getElementById('buttonY')
var DivSummary = document.getElementsByClassName('LoginSumParent')[0];
var DivSummarySignUp = document.getElementsByClassName('SignUpParent')[0];

LoginButton.onclick = function ()
{
    DivSummary.style.display = 'block';
}



XButton.onclick = function () {
    DivSummary.style.display = 'none';
    DivSummarySignUp.style.display = 'none';
}

YButton.onclick = function () {
    DivSummary.style.display = 'none';
}






