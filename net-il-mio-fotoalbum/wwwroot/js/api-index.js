const loadPhotos = filter => getPhotos(filter).then(renderPhotos);

const getPhotos = title => axios
    .get('/api/photo', title ? { params: { title } } : {})
    .then(res => res.data);

const renderPhotos = photos => {
    const emptyMessage = document.querySelector("#emptyMessage");
    const loader = document.querySelector("#loader");
    const tbody = document.querySelector("#photoList");
    const table = document.querySelector("#table");
    //const filter = document.querySelector("#filter");

    if (photos && photos.length > 0) {
        table.style.display = "block";
        //filter.style.display = "block";
        emptyMessage.style.display = "none";
    }
    else emptyMessage.style.display = "block";

    loader.style.display = "none";

    tbody.innerHTML = photos.map(photoComponent).join('');
};

//const initFilter = () => {
//    const filter = document.querySelector("#filter input");
//    filter.addEventListener("keyup", (e) => loadPizzas(e.target.value))
//};

const photoComponent = photo => `

    <div class="col-12 col-md-6 text-center d-flex flex-column align-items-center py-3 justify-content-center">
        <div class="d-flex flex-column px-2 w-100 h-100">
            <div class="w-100 h-100">
                <img class="h-100 w-100" style="object-fit: cover;" src="/${photo.url}" alt="...">
            </div>
            <h5>${photo.title}</h5>
            <p>${photo.description}</p>
        </div>
    </div>

    `;