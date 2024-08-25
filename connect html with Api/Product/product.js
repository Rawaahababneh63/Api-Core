var n = Number(localStorage.getItem("categoryId"));
console.log(n);
var url;

if ( n==0) {
    url = 'https://localhost:44329/api/Product';
} else {
    url = `https://localhost:44329/api/Product/ProductbyGetCategoryId/${n}`;
}

async function GetCategories() {
    var response = await fetch(url);
    var result = await response.json();

    var container = document.getElementById('container');
    container.innerHTML = '';

    result.forEach(element => {
        container.innerHTML += `
            <div class="card" d-flex flex-row>
                <img class="card-img-top" src="${element.productImage}" alt="Card image cap">
                <div class="card-body">
                    <h5 class="card-title">${element.productName}</h5>
                    <p class="card-text">${element.categoryId}</p>
                    <button onClick="store(${element.productId})">عرض التفاصيل</button>
                </div>
            </div>
            <br><br>
        `;
    });
}

function store(x) {
    localStorage.setItem('productId', x);
    window.location.href = 'details.html'; 
}

GetCategories();
