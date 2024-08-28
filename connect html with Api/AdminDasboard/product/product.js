


var n = Number(localStorage.getItem("CategoryId"));
console.log(n);
var url;

if ( n==0) {
    url = 'https://localhost:44329/api/Product';
} 

else {
    url = `https://localhost:44329/api/Product/ProductbyGetCategoryId/${n}`;
}

async function GetProduct() {
    var response = await fetch(url);
    var result = await response.json();

    var table = document.getElementById('table');
    table.innerHTML = '';

    result.forEach(element => {
       table.innerHTML += `

  
        <tr>
        <th scope="row">${element.productId}</th>
        <td>${element.productName}</td>
        <td><img src="${element.productImage}"></td>
        <td><img src="${element.price}"></td>
        <td><button onclick="myFunction(${element.productId})">Edit</button></td>
      </tr>


        `
    });
};

function myFunction(id){
    
    localStorage.setItem('productId', id);
    window.location.href = 'edit/edit.html'; 
}
function store(x) {
    localStorage.setItem('productId', x);
    window.location.href = 'details.html'; 
}
function editproduct(x) {

    localStorage.setItem('productId', x);
    window.location.href = 'edit/edit.html'; 
}
function addproduct(x) {
    

    window.location.href = 'add/add.html'; 
}

GetProduct();
