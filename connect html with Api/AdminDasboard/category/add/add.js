const url="https://localhost:44329/api/Categories";

var form=document.getElementById("form");
async function addcategory(){
event.preventDefault();
var formData= new FormData(form);
let response=await fetch(url,{
    method:"POST",
    body:formData,
});
var data=response;

   alert("New Category added Sucessfully");

}