const serverUrl = "https://localhost:5001/";


function OnRegister() {
    
    const user_name = document.getElementById("user_name");
    const pw = document.getElementById("pw");

    var data = new FormData();
    data.append('User_Name', user_name.value);
    data.append('pw', pw.value);


    console.log(data);

    var xhr = new XMLHttpRequest();
    xhr.open('POST', serverUrl + 'api/Books/RegisterUser');
    alert("Registered! Please Log in.")
    console.log(data);
    xhr.send(data);

}