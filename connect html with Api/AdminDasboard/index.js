var n = Number(localStorage.getItem("categoryId"));
console.log(n);
var url;

if ( n==0) {
    url = 'https://localhost:44329/api/Product';
} else {
    url = `https://localhost:44329/api/Categories/UpdateCategorybyCategoryid${n}`;
}

async function GetProduct() {
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
                       <button onClick="addproduct(${element.productId})">اضافة المنتجات</button>
                          <button onClick="editproduct(${element.productId})">تعديل المنتجات</button>
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
function editproduct(x) {
    
    localStorage.setItem('productId', x);
    window.location.href = '../editProduct/editproduct.html'; 
}
function addproduct(x) {
    localStorage.setItem('productId', x);
    window.location.href = '../AddProduct/AddProduct.html'; 
}

GetProduct();
