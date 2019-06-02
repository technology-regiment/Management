import * as usersService from './service';

export default {
  namespace: 'user-dashboard',
  state: {
    data: {
      Results: [],
      Pagination: {},
    },
    user:{},
    filter: {},
    pagination: {
      orderProperty: 'Name',
      ascending: false,
      pageNumber: 1,
      pageSize: 10,
    },
  },
  reducers: {
    save(state, action) {
      return {
        ...state,
        data: action.payload,
      };
    },
    saveUser(state,action){
      return{
        ...state,
        user:action.payload,
      }
    }
  },
 
  effects: {
    *fetch({ payload }, { call, put }) {
      const response = yield call(usersService.fetch, payload);
      yield put({
        type: 'save',
        payload: response,
      });
    },
    *getById({payload:Id},{call,put}){
      const response= yield call(usersService.getById,Id);
      yield put({
        type:'saveUser',
        payload:response,
      })
    },

    *create({ payload: values }, { call, put, select }) {
      yield call(usersService.create, values);
      const filter = yield select(state => state['user-dashboard'].filter);
      const pagination = yield select(state => state['user-dashboard'].pagination);
      yield put({ type: 'fetch', payload: { filter, ...pagination } });
    },

    *patch({ payload: editValues }, { call, put, select }) {
      yield call(usersService.edit, editValues);
      const filter = yield select(state => state['user-dashboard'].filter);
      const pagination = yield select(state => state['user-dashboard'].pagination);
      yield put({ type: 'fetch', payload: { filter, ...pagination } });
    },

    *remove({ payload: Id }, { call, put, select }) {
      yield call(usersService.remove, Id);
      const filter = yield select(state => state['user-dashboard'].filter);
      const pagination = yield select(state => state['user-dashboard'].pagination);
      yield put({ type: 'fetch', payload: { filter, ...pagination } });
    },
  },
};
