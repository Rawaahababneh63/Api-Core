
const url ='https://localhost:44329/api/Categories';


async function GetCategories() {


    var response  = await fetch(url);

    var result = await response.json();
    console.log(result);
    var table = document.getElementById('table');

result.forEach(element => {

   table.innerHTML+=`

      
                  
                      <tr>
                        <th scope="row">${element.categoryId}</th>
                        <td>${element.categoryName}</td>
                        <td><img src="${element.categoryImage}"></td>
                         <td><a href="#" onclick="editCategory(${element.categoryId})">Edit</a></td>
                      </tr>
                 
              `




});
}


function store(x) {

localStorage.clear();
    window.location.href = '../Product/product.html';
;
}


function stores(x) {
  localStorage.setItem=("CategoryId" , localStorage.categoryId=x);
    window.location.href = '../Product/product.html';
   }
   function editCategory(x) {
    localStorage.setItem=("CategoryId" , localStorage.categoryId=x);
    window.location.href = 'edit/edit.html';
     }
     function addcategory(x) {
        localStorage.setItem=("CategoryId" , localStorage.categoryId=x);
          window.location.href = 'add/add.html';
         }
GetCategories();