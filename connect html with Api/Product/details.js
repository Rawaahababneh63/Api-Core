var n = localStorage.getItem("productId");
console.log(n);
var
    url = `https://localhost:44329/api/Product/product/${n}`;

async function GetCategories() {

    var response = await fetch(url);

    var result = await response.json();

    var container = document.getElementById('container');

   
        container.innerHTML = `
<div class="card">
                <img class="card-img-top" src="${result.productImage}" alt="Card image cap">
                <div class="card-body">
                    <h5 class="card-title">${result.productName}</h5>
                    <p class="card-text">${result.categoryId}</p>
                    <p class="card-text">${result.description}</p>
                      
                        <input type="number" id="inputQutity">
  <button onclick="addToCart()">اضافة للسلة</button> 
                </div>
            </div>

`



}

GetCategories();

const urlofCart='https://localhost:44329/api/CartItem';

async function addToCart() {debugger
var Quntity=document.getElementById("inputQutity");
   var request=await fetch(urlofCart,
   {
     method:'POST',
     headers:{'Content-Type':'application/json'},
     body:JSON.stringify({
       
        cartId:localStorage.cartId=1,
productId:localStorage.getItem("productId"),
quantity:Quntity.value
     })

    
   }
)

alert("Item Add Successfully");
}
