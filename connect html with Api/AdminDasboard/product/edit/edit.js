
debugger
var n = Number(localStorage.getItem("productId"));
console.log(n);

const url=`https://localhost:44329/api/Product/UpdateProductbyProductid${n}`;

var form=document.getElementById("form");
async function EditProduct(event){
    // هاي بتمنع يصير ريللود على صفحة ثانية
event.preventDefault();
var formData= new FormData(form);
let response=await fetch(url,{
    method:"PUT",
    body:formData,
});
var data=await response.json();
alert(" Product edit Sucessfully");



}