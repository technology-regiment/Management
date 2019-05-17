import request from '@/utils/request';

export function fetch(params) {
  return request.post('/api/users/pagination', { data: params });
}

export function create(values) {
  return request.post('/api/users', { data: values });
}

export function edit(editValues) {
  return request.put('/api/users', { data: editValues });
}
export function remove(Id) {
  return request.delete('/api/users/' + Id);
}
