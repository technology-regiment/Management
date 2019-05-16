import { connect } from 'dva';
import { Table, Pagination, Popconfirm, Button } from 'antd';
import { routerRedux } from 'dva/router';
import styles from './Users.css';
import { PAGE_SIZE } from '../utils/constants';
import UserModal from './UserModal';

function Users({ dispatch, loading ,data}) {

 


  function deleteHandler(id) {
    dispatch({
      type: 'user-dashboard/remove',
      payload: id,
    });
  }

  function pageChangeHandler(page) {
    dispatch({
      type: 'user-dashboard/fetch',
      payload: { page },
    });
  }

  function editHandler(id, values) {
    dispatch({
      type: 'user-dashboard/patch',
      payload: { id, values },
    });
  }

  function createHandler(values) {
    dispatch({
      type: 'user-dashboard/create',
      payload: values,
    });
  }

  const columns = [
    {
      title: '用户姓名',
			dataIndex: 'Name',
    },
    {
      title: 'Operation',
      key: 'operation',
      render: (text, record) => (
        <span className={styles.operation}>
          <UserModal record={record} onOk={editHandler.bind(null, record.id)}>
            <a>Edit</a>
          </UserModal>
          <Popconfirm title="Confirm to delete?" onConfirm={deleteHandler.bind(null, record.id)}>
            <a href="">Delete</a>
          </Popconfirm>
        </span>
      ),
    },
  ];

  return (
    <div className={styles.normal}>
      <div>
        <div className={styles.create}>
          <UserModal record={{}} onOk={createHandler}>
            <Button type="primary">Create User</Button>
          </UserModal>
        </div>
        <Table
          loading={loading}
          columns={columns}
          dataSource={data.Results}
          rowKey={record => record.id}
          pagination={false}
        />
        <Pagination
          className="ant-table-pagination"
          total={data.Pagination.Total}
          current={data.Pagination.Current}
          pageSize={data.Pagination.PageSize}
          onChange={pageChangeHandler}
        />
      </div>
    </div>
  );
}

function mapStateToProps(state) {
  const {   page ,data} = state['user-dashboard'];
  return {
    data,
    loading: state.loading.models['user-dashboard'],
  };
}

export default connect(mapStateToProps)(Users);
