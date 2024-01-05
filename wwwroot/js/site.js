
let form = document.getElementById('form');
form.addEventListener('submit', New_User);


function New_User(event)
{
    event.preventDefault();
    
    let div = document.createElement('div');

    let name = form.querySelector(`[name="user_Name"]`);

    console.log(name);
    let close1 = document.createElement('div');



    close1.className = "x2716"
    div.className = "alert";

    div.innerHTML = `Пользователь <strong>${name}</strong> добавлен.`;

    document.body.append(div);

    document.body.append(close1);
}

close1.onclick = function () {
    setTimeout(() => div.remove(), 300)
}


