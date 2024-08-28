const url="https://localhost:44329/api/Product";

var form=document.getElementById("form");
async function addproduct(){
event.preventDefault();
var formData= new FormData(form);
let response=await fetch(url,{
    method:"POST",
    body:formData,
});
var data=response;
window.location.href="../editProduct/editproduct.html"



}