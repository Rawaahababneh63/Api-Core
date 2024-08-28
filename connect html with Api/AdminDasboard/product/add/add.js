

const url="https://localhost:44329/api/Product";

var form=document.getElementById("form");
var option=document.getElementById("options");
async function addproduct(){
event.preventDefault();
var formData= new FormData(form);
let response=await fetch(url,{
    method:"POST",
    body:formData,
});
var data=response;
alert("New Product added Sucessfully");



}


async function categoriesID(){
 
     const response = await fetch('https://localhost:44329/api/Categories');
        let data = await response.json();
      
       data.forEach((element) => {
         data.innerHTML += `<option value="${element.categoryId}">${element.categoryName}</option>`;
        });}
     categoriesID();