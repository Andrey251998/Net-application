
document.getElementById('switch').style.position = "absolute";
document.getElementById('switch').style.left = "50%";
document.getElementById('switch').style.translate = "-50% 0";
document.getElementById('switch').style.margin = "-6px"
document.getElementById('auth').style.padding = "12px";
document.getElementById('reg').style.padding = "12px";
document.getElementById('auth').style.border = 0;
document.getElementById('reg').style.border = 0;
document.getElementById('auth').style.background = "white";
document.getElementById('reg').style.background = "cadetblue";
document.getElementById('auth').style.borderRadius = "12px";
document.getElementById('reg').style.borderRadius = "12px";
document.getElementById('reg').style.fontFamily = "cursive";
document.getElementById('auth').style.fontFamily = "cursive";
document.getElementById('reg').style.fontSize = "16px";
document.getElementById('auth').style.fontSize = "16px";
document.getElementById('reg').style.boxShadow = "0 0 20px 0 rgba(0, 0, 0, 0.2), 0 5px 5px 0 rgba(0, 0, 0, 0.24)";
document.getElementById('auth').style.boxShadow = "0 0 20px 0 rgba(0, 0, 0, 0.2), 0 5px 5px 0 rgba(0, 0, 0, 0.24)";



document.getElementById('box1').style.position = "absolute";
document.getElementById('box1').style.left = "50%";
document.getElementById('box1').style.background = "cadetblue";
document.getElementById('box1').style.width = "350px";
document.getElementById('box1').style.height = "192px";
document.getElementById('box1').style.paddingTop = "12px";
document.getElementById('box1').style.paddingLeft = "12px";
document.getElementById('box1').style.translate = "-50% 15%";
document.getElementById('box1').style.boxShadow = "0 0 20px 0 rgba(0, 0, 0, 0.2), 0 5px 5px 0 rgba(0, 0, 0, 0.24)";
document.getElementById('box1').style.borderRadius = "12px";

document.getElementById('button1').style.margin = "10px auto";
document.getElementById('button1').style.display = "block";
document.getElementById('button1').style.paddingLeft = "20px";
document.getElementById('button1').style.paddingRight = "20px";



document.getElementById('in_l1').style.marginBottom = "20px";
document.getElementById('in_l1').style.padding = "10px";
document.getElementById('in_l1').style.marginLeft = "16px";
document.getElementById('in_l1').style.width = "70%"

document.getElementById('font_l1').style.fontFamily = "cursive";
document.getElementById('font_l1').style.fontSize = "16px";

document.getElementById('in_p1').style.marginBottom = "10px";
document.getElementById('in_p1').style.padding = "10px";
document.getElementById('in_p1').style.marginLeft = "6px";
document.getElementById('in_p1').style.width = "70%"

document.getElementById('font_p1').style.fontFamily = "cursive";
document.getElementById('font_p1').style.fontSize = "16px";






document.getElementById('box').style.position = "absolute";
document.getElementById('box').style.left = "50%";
document.getElementById('box').style.background = "cadetblue";
document.getElementById('box').style.width = "350px";
document.getElementById('box').style.paddingTop = "12px";
document.getElementById('box').style.paddingLeft = "12px";
document.getElementById('box').style.translate = "-50% 15%";
document.getElementById('box').style.boxShadow = "0 0 20px 0 rgba(0, 0, 0, 0.2), 0 5px 5px 0 rgba(0, 0, 0, 0.24)";
document.getElementById('box').style.borderRadius = "12px";

document.getElementById('button').style.margin = "12px auto";
document.getElementById('button').style.display = "block";

document.getElementById('font_e').style.fontFamily = "cursive";
document.getElementById('font_e').style.fontSize = "16px";

document.getElementById('in_e').style.padding = "10px";
document.getElementById('in_e').style.marginLeft = "16px";
document.getElementById('in_e').style.marginBottom = "10px";
document.getElementById('in_e').style.width = "70%"

document.getElementById('in_l').style.marginBottom = "10px";
document.getElementById('in_l').style.padding = "10px";
document.getElementById('in_l').style.marginLeft = "16px";
document.getElementById('in_l').style.width = "70%"

document.getElementById('font_l').style.fontFamily = "cursive";
document.getElementById('font_l').style.fontSize = "16px";

document.getElementById('in_p').style.marginBottom = "10px";
document.getElementById('in_p').style.padding = "10px";
document.getElementById('in_p').style.marginLeft = "6px";
document.getElementById('in_p').style.width = "70%"

document.getElementById('font_p').style.fontFamily = "cursive";
document.getElementById('font_p').style.fontSize = "16px";

let l = document.getElementById('box1');
let r = document.getElementById('box')
function Show_reg() {
    l.hidden = true;
    r.hidden = false;
    document.getElementById('reg').style.background = "cadetblue";
    document.getElementById('auth').style.background = "white";
    
}
function Show_log() {
    l.hidden = false;
    r.hidden = true;
    document.getElementById('auth').style.background = "cadetblue";
    document.getElementById('reg').style.background = "white";
}