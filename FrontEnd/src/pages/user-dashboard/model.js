import * as usersService from './service';

export default {
  namespace: 'user-dashboard',
  state: {
   data:{
     Result:[],
     Pagination:{}
   }
  },
  reducers: {
    save(state,action) {
      return {
      ...state,
      data: action.payload
     };
    },
  },
  effects: {
    *fetch( {payload}, { call, put }) {
      const response = yield call(usersService.fetch, payload);
      yield put({
        type: 'save',
        payload: response,
        
      });
    },

    *remove({ payload: id }, { call, put, select }) {
      yield call(usersService.remove, id);
      const page = yield select(state => state['user-dashboard'].page);
      yield put({ type: 'fetch', payload: { page } });
    },
    *patch({ payload: { id, values } }, { call, put, select }) {
      yield call(usersService.patch, id, values);
      const page = yield select(state => state['user-dashboard'].page);
      yield put({ type: 'fetch', payload: { page } });
    },
    *create({ payload: values }, { call, put, select }) {
      yield call(usersService.create, values);
      const page = yield select(state => state['user-dashboard'].page);
      yield put({ type: 'fetch', payload: { page } });
    },
  },
};
