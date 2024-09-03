
const url ='https://localhost:44329/api/Categories';


async function GetCategories() {


    var response  = await fetch(url);

    var result = await response.json();
    console.log(result);
    var container = document.getElementById('container');

result.forEach(element => {

    container.innerHTML+=`
<div class="card" >
    <img class="card-img-top" src="${element.categoryImage}" alt="Card image cap">
    <div class="card-body">
      <h5 class="card-title">|${element.categoryName}</h5>
      <p class="card-text">${element.categoryId}</p>

      <button onClick="store(${element.categoryId})">store data</button>
      <button onClick="stores(${element.categoryId})">next page</button>
      <button onClick="editCategory(${element.categoryId})">editCategory</button>
     
    </div>
  </div>
<br><br>
`





//     var div  = document.createElement('div');
//     div.classList.add('card');

 
       
//     var div2  = document.createElement('div');
//      div2.classList.add('card-body');

//      div.appendChild(div2);

//      var img  = document.createElement('img');
//      img.classList.add('card-img-top');
//      img.src=element.categoryImage;
//         div2.appendChild(img);
        
//      var h5  = document.createElement('h5');
//      h5.classList.add('card-title');
//      h5.textContent = element.categoryName;

//      div2.appendChild(h5);

//      var p = document.createElement('p');
//      p.classList.add('card-text');
//      p.textContent = element.categoryId;
// div2.appendChild(p);


  

//      container.appendChild(div);
})
};


function store(x) {
// لحذف اشي معين من localstorage
  localStorage.removeItem('categoryId');

    window.location.href = '../Product/product.html';
;
}


function stores(x) {
  localStorage.setItem=(" CategoryId" ,x);
    window.location.href = '../Product/product.html';
   }
   function editCategory(x) {
    localStorage.setItem=(" CategoryId" , localStorage.categoryId=x);
      window.location.href = '../EditCategory/editcategory.html';
     }

     function SaveId() {
      localStorage.PID=1;
      localStorage.CartID=1;
      
     }

 
GetCategories();