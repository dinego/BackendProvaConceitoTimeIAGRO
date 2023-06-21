const apiUrl = 'https://localhost:7289/api/';

export const environment = {
  Book: {
    GetAll: `${apiUrl}Book/GetAll`,
    GetBySpecification: `${apiUrl}Book/GetBySpecification`,
    SortByPrice: `${apiUrl}Book/SortByPrice`,
  },
};
