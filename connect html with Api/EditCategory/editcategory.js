var n = Number(localStorage.getItem("categoryId"));
console.log(n);

const url=`https://localhost:44329/api/Categories/UpdateCategorybyCategoryid${n}`;

var form=document.getElementById("form");
async function EditCategory(){
    // هاي بتمنع يصير ريللود على صفحة ثانية
event.preventDefault();
var formData= new FormData(form);
let response=await fetch(url,{
    method:"PUT",
    body:formData,
});
var data=await response.json();




}