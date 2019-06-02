import { connect } from 'dva';
import { Component } from 'react';
import { Table, Pagination, Popconfirm, Button, Input, Row, Col, message } from 'antd';
import { routerRedux } from 'dva/router';
import styles from './Users.css';
import RoleModal from './RoleModal';

@connect(({ role, loading }) => ({
  role,
  loading: loading.effects['role/fetch'],
}))

class Roles extends Component {

  state = {
    filter: {},
    pagination: {
      orderProperty: 'Name',
      ascending: false,
      pageNumber: 1,
      pageSize: 10,
    },
  };

  getByPage = () => {
    const { filter, pagination } = this.state;
    this.props.dispatch({
      type: 'role/fetch',
      payload: {
        filter,
        ...pagination,
      },
    });
  };


  componentDidMount() {
    this.getByPage();
  }

  createHandler = (values) => {
    const { dispatch } = this.props;
    dispatch({
      type: 'role/create',
      payload: values,
    });
    message.success("添加成功");
  };
   editHandler=(Id, values)=> {
    const { dispatch } = this.props;
    const editValues = { Id, ...values };
    dispatch({
      type: 'role/patch',
      payload: editValues,
    });
    message.success("修改成功");
  }
   deleteHandler=(Id)=> {
    const { dispatch } = this.props;
    dispatch({
      type: 'role/remove',
      payload: Id,
    });
    message.success("删除成功")
  }

  pageChangeHandler = (page) => {
    dispatch({
      type: 'user-dashboard/fetch',
      payload: { page },
    });
  }
  render() {
    const { Search } = Input
    const { role, loading } = this.props;
    const { data } = role;
    const columns = [
      {
        title: '角色名称',
        dataIndex: 'Name',
        key: 'name',
      },
      {
        title: '角色描述',
        dataIndex: 'Description',
        key: 'description',
      },
      {
        title: '操作',
        key: 'operation',
        render: (text, record) => (
          <span className={styles.operation}>
            <RoleModal record={record} onOk={this.editHandler.bind(null, record.Id)}>
              <a>修改</a>
            </RoleModal>
            <Popconfirm title="确定删除?" onConfirm={this.deleteHandler.bind(null, record.Id)}>
              <a href="">删除</a>
            </Popconfirm>
          </span>
        ),
      },
    ];


    return (
      <div className={styles.normal}>
        <div>
          <div>
            <Row >
              <Col span={4}>
                <Search
                placeholder="角色名称"
                />
              </Col>
            </Row>
          </div>
          <div className={styles.create}>
            <RoleModal record={{}} onOk={this.createHandler}>
              <Button type="primary">新增角色</Button>
            </RoleModal>
          </div>
          <Table
            loading={loading}
            columns={columns}
            dataSource={data.Results}
            rowKey="Id"
            pagination={false}
          />
          <Pagination
            className="ant-table-pagination"
            total={data.Pagination.Total}
            current={data.Pagination.Current}
            pageSize={data.Pagination.PageSize}
            onChange={this.pageChangeHandler}
          />
        </div>
      </div>
    );
  }
}

export default Roles;

