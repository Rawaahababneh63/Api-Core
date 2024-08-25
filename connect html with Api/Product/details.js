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
                </div>
            </div>

`



}

GetCategories();
