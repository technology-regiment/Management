import request from '@/utils/request';

export function fetch(params) {
  return request.post('/api/roles/pagination', { data: params });
}

export function create(values) {
  return request.post('/api/roles', { data: values });
}

export function edit(editValues) {
  return request.put('/api/roles', { data: editValues });
}
export function remove(Id) {
  return request.delete('/api/roles/' + Id);
}
