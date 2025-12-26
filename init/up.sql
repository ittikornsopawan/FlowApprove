CREATE DATABASE IF NOT EXISTS postgres;

CREATE TABLE IF NOT EXISTS t_workflow
(
    id UUID NOT NULL DEFAULT GEN_RANDOM_UUID() PRIMARY KEY,
    created_by VARCHAR(64) NOT NULL,
    created_at TIMESTAMP WITHOUT TIME ZONE NOT NULL DEFAULT CURRENT_TIMESTAMP,
    updated_by VARCHAR(64),
    updated_at TIMESTAMP WITHOUT TIME ZONE,

    is_active BOOLEAN NOT NULL DEFAULT TRUE,
    inactive_at TIMESTAMP WITHOUT TIME ZONE,
    inactive_by VARCHAR(64),

    is_deleted BOOLEAN NOT NULL DEFAULT FALSE,
    deleted_at TIMESTAMP WITHOUT TIME ZONE,
    deleted_by VARCHAR(64),

    type VARCHAR(16) NOT NULL CHECK (type IN ('APPROVAL', 'NOTIFICATION', 'TASK', 'HYBRID')),
    name VARCHAR(128) NOT NULL,
    description TEXT
);

CREATE TABLE IF NOT EXISTS t_workflow_node
(
    id UUID NOT NULL DEFAULT GEN_RANDOM_UUID() PRIMARY KEY,
    created_by VARCHAR(64) NOT NULL,
    created_at TIMESTAMP WITHOUT TIME ZONE NOT NULL DEFAULT CURRENT_TIMESTAMP,
    updated_by VARCHAR(64),
    updated_at TIMESTAMP WITHOUT TIME ZONE,

    is_active BOOLEAN NOT NULL DEFAULT TRUE,
    inactive_at TIMESTAMP WITHOUT TIME ZONE,
    inactive_by VARCHAR(64),

    is_deleted BOOLEAN NOT NULL DEFAULT FALSE,
    deleted_at TIMESTAMP WITHOUT TIME ZONE,
    deleted_by VARCHAR(64),

    workflow_id UUID NOT NULL REFERENCES t_workflow(id),
    type VARCHAR(32) NOT NULL CHECK (type IN ('BEGIN', 'END', 'APPROVAL', 'NOTIFICATION', 'TASK')),
    sequence INT NOT NULL,
    name VARCHAR(128) NOT NULL,
    description TEXT,

    approver_source NOT NULL VARCHAR(32) CHECK (approver_source IN ('STATIC', 'DYNAMIC', 'EXTERNAL')),
    approval_policy VARCHAR(32) CHECK (approval_policy IN ('ALL', 'ANY'))
);

CREATE TABLE IF NOT EXISTS t_workflow_node_assignment
(
    id UUID NOT NULL DEFAULT GEN_RANDOM_UUID() PRIMARY KEY,
    created_by VARCHAR(64) NOT NULL,
    created_at TIMESTAMP WITHOUT TIME ZONE NOT NULL DEFAULT CURRENT_TIMESTAMP,
    updated_by VARCHAR(64),
    updated_at TIMESTAMP WITHOUT TIME ZONE,

    is_active BOOLEAN NOT NULL DEFAULT TRUE,
    inactive_at TIMESTAMP WITHOUT TIME ZONE,
    inactive_by VARCHAR(64),

    is_deleted BOOLEAN NOT NULL DEFAULT FALSE,
    deleted_at TIMESTAMP WITHOUT TIME ZONE,
    deleted_by VARCHAR(64),

    node_id UUID NOT NULL REFERENCES t_workflow_node(id),
    assignee_type VARCHAR(32) NOT NULL,
    assignee_name VARCHAR(256) NOT NULL,
    assignee_contact VARCHAR(32) NOT NULL
);

CREATE TABLE IF NOT EXISTS t_workflow_node_task
(
    id UUID NOT NULL DEFAULT GEN_RANDOM_UUID() PRIMARY KEY,
    created_by VARCHAR(64) NOT NULL,
    created_at TIMESTAMP WITHOUT TIME ZONE NOT NULL DEFAULT CURRENT_TIMESTAMP,
    updated_by VARCHAR(64),
    updated_at TIMESTAMP WITHOUT TIME ZONE,

    is_active BOOLEAN NOT NULL DEFAULT TRUE,
    inactive_at TIMESTAMP WITHOUT TIME ZONE,
    inactive_by VARCHAR(64),

    is_deleted BOOLEAN NOT NULL DEFAULT FALSE,
    deleted_at TIMESTAMP WITHOUT TIME ZONE,
    deleted_by VARCHAR(64),

    node_id UUID NOT NULL REFERENCES t_workflow_node(id),
    request_method VARCHAR(16) NOT NULL,
    request_url TEXT NOT NULL,
    request_header JSONB,
    request_payload JSONB,
);

CREATE TABLE IF NOT EXISTS t_workflow_transition
(
    id UUID NOT NULL DEFAULT GEN_RANDOM_UUID() PRIMARY KEY,
    created_by VARCHAR(64) NOT NULL,
    created_at TIMESTAMP WITHOUT TIME ZONE NOT NULL DEFAULT CURRENT_TIMESTAMP,
    updated_by VARCHAR(64),
    updated_at TIMESTAMP WITHOUT TIME ZONE,

    is_active BOOLEAN NOT NULL DEFAULT TRUE,
    inactive_at TIMESTAMP WITHOUT TIME ZONE,
    inactive_by VARCHAR(64),

    is_deleted BOOLEAN NOT NULL DEFAULT FALSE,
    deleted_at TIMESTAMP WITHOUT TIME ZONE,
    deleted_by VARCHAR(64),

    workflow_id UUID NOT NULL REFERENCES t_workflow(id),
    from_node_id UUID NOT NULL REFERENCES t_workflow_node(id),
    to_node_id UUID NOT NULL REFERENCES t_workflow_node(id),
    condition JSONB,
    name VARCHAR(128) NOT NULL,
    description TEXT
);

CREATE TABLE IF NOT EXISTS m_request
(
    id UUID NOT NULL DEFAULT GEN_RANDOM_UUID() PRIMARY KEY,
    created_by VARCHAR(64) NOT NULL,
    created_at TIMESTAMP WITHOUT TIME ZONE NOT NULL DEFAULT CURRENT_TIMESTAMP,
    updated_by VARCHAR(64),
    updated_at TIMESTAMP WITHOUT TIME ZONE,

    is_active BOOLEAN NOT NULL DEFAULT TRUE,
    inactive_at TIMESTAMP WITHOUT TIME ZONE,
    inactive_by VARCHAR(64),

    is_deleted BOOLEAN NOT NULL DEFAULT FALSE,
    deleted_at TIMESTAMP WITHOUT TIME ZONE,
    deleted_by VARCHAR(64),

    workflow_id UUID NOT NULL REFERENCES t_workflow(id),
    name VARCHAR(128) NOT NULL,
    description TEXT
);

CREATE TABLE IF NOT EXISTS m_request_property
(
    id UUID NOT NULL DEFAULT GEN_RANDOM_UUID() PRIMARY KEY,
    created_by VARCHAR(64) NOT NULL,
    created_at TIMESTAMP WITHOUT TIME ZONE NOT NULL DEFAULT CURRENT_TIMESTAMP,
    updated_by VARCHAR(64),
    updated_at TIMESTAMP WITHOUT TIME ZONE,

    is_active BOOLEAN NOT NULL DEFAULT TRUE,
    inactive_at TIMESTAMP WITHOUT TIME ZONE,
    inactive_by VARCHAR(64),

    is_deleted BOOLEAN NOT NULL DEFAULT FALSE,
    deleted_at TIMESTAMP WITHOUT TIME ZONE,
    deleted_by VARCHAR(64),

    request_id UUID NOT NULL REFERENCES m_request(id),
    key VARCHAR(128) NOT NULL,
    title VARCHAR(256) NOT NULL,
    type VARCHAR(64) NOT NULL,
    description TEXT,
    is_required BOOLEAN NOT NULL DEFAULT FALSE
);

CREATE TABLE IF NOT EXISTS t_request_workflow_instance
(
    id UUID NOT NULL DEFAULT GEN_RANDOM_UUID() PRIMARY KEY,
    created_by VARCHAR(64) NOT NULL,
    created_at TIMESTAMP WITHOUT TIME ZONE NOT NULL DEFAULT CURRENT_TIMESTAMP,
    updated_by VARCHAR(64),
    updated_at TIMESTAMP WITHOUT TIME ZONE,

    is_active BOOLEAN NOT NULL DEFAULT TRUE,
    inactive_at TIMESTAMP WITHOUT TIME ZONE,
    inactive_by VARCHAR(64),

    is_deleted BOOLEAN NOT NULL DEFAULT FALSE,
    deleted_at TIMESTAMP WITHOUT TIME ZONE,
    deleted_by VARCHAR(64),

    request_id UUID NOT NULL REFERENCES m_request(id),
    workflow_id UUID NOT NULL REFERENCES t_workflow(id),
    current_node_id UUID REFERENCES t_workflow_node(id),
    status VARCHAR(32) NOT NULL CHECK (status IN ('PENDING', 'IN_PROGRESS', 'COMPLETED', 'REJECTED', 'CANCELLED'))
);

CREATE TABLE IF NOT EXISTS t_request_workflow_instance_node
(
    id UUID NOT NULL DEFAULT GEN_RANDOM_UUID() PRIMARY KEY,
    created_by VARCHAR(64) NOT NULL,
    created_at TIMESTAMP WITHOUT TIME ZONE NOT NULL DEFAULT CURRENT_TIMESTAMP,
    updated_by VARCHAR(64),
    updated_at TIMESTAMP WITHOUT TIME ZONE,

    is_active BOOLEAN NOT NULL DEFAULT TRUE,
    inactive_at TIMESTAMP WITHOUT TIME ZONE,
    inactive_by VARCHAR(64),

    is_deleted BOOLEAN NOT NULL DEFAULT FALSE,
    deleted_at TIMESTAMP WITHOUT TIME ZONE,
    deleted_by VARCHAR(64),

    instance_id UUID NOT NULL REFERENCES t_request_workflow_instance(id),
    node_id UUID NOT NULL REFERENCES t_workflow_node(id),
    status VARCHAR(32) NOT NULL CHECK (status IN ('PENDING', 'IN_PROGRESS', 'COMPLETED', 'REJECTED', 'CANCELLED')),
    started_at TIMESTAMP WITHOUT TIME ZONE,
    completed_at TIMESTAMP WITHOUT TIME ZONE
);

CREATE TABLE IF NOT EXISTS t_request_workflow_instance_node_assignment
(
    id UUID NOT NULL DEFAULT GEN_RANDOM_UUID() PRIMARY KEY,
    created_by VARCHAR(64) NOT NULL,
    created_at TIMESTAMP WITHOUT TIME ZONE NOT NULL DEFAULT CURRENT_TIMESTAMP,
    updated_by VARCHAR(64),
    updated_at TIMESTAMP WITHOUT TIME ZONE,

    is_active BOOLEAN NOT NULL DEFAULT TRUE,
    inactive_at TIMESTAMP WITHOUT TIME ZONE,
    inactive_by VARCHAR(64),

    is_deleted BOOLEAN NOT NULL DEFAULT FALSE,
    deleted_at TIMESTAMP WITHOUT TIME ZONE,
    deleted_by VARCHAR(64),

    instance_node_id UUID NOT NULL REFERENCES t_request_workflow_instance_node(id),
    assignee_type VARCHAR(32) NOT NULL,
    assignee_name VARCHAR(256) NOT NULL,
    assignee_contact VARCHAR(32) NOT NULL,
    decision VARCHAR(32) CHECK (decision IN ('PENDDING', 'APPROVED', 'REJECTED', 'REVISED', 'TASK_DONE', 'TASK_RETRY', 'CANCELLED')),
    decision_at TIMESTAMP WITHOUT TIME ZONE,
    comments TEXT
);

CREATE TABLE IF NOT EXISTS t_request_workflow_instance_history
(
    id UUID NOT NULL DEFAULT GEN_RANDOM_UUID() PRIMARY KEY,
    created_by VARCHAR(64) NOT NULL,
    created_at TIMESTAMP WITHOUT TIME ZONE NOT NULL DEFAULT CURRENT_TIMESTAMP,
    
    instance_id UUID NOT NULL REFERENCES t_request_workflow_instance(id),
    node_id UUID REFERENCES t_workflow_node(id),
    action VARCHAR(128) NOT NULL,
    decision VARCHAR(32) CHECK (decision IN ('PENDDING', 'APPROVED', 'REJECTED', 'REVISED', 'TASK_DONE', 'TASK_RETRY', 'CANCELLED')),
    request JSONB,
    response JSONB,
    comments TEXT
);